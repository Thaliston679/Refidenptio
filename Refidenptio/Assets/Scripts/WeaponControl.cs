using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponControl : MonoBehaviour
{
    //bullet 
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //Status da arma
    public float timeBetweenShooting/*Tempo entre tiros*/, spread/*Espalhar*/, reloadTime/*Tempo de recarga*/, timeBetweenShots/*Tempo entre tiros*/;
    public int magazineSize/*Tamanho do pente*/, bulletsPerTap/*Balas por tiro*/;
    public bool allowButtonHold/*Para armas que podem segurar o gatilhpo*/;

    int bulletsLeft/*Balas restantes*/, bulletsShot/*Balas disparadas*/;

    //bools
    public bool shooting/*Atirando*/, readyToShoot/*Pronto pra atirar*/;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing :D
    public bool allowInvoke = true;

    private void Awake()
    {
        //Recarga total ao iniciar
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        //Mostra municao na tela
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }
    private void MyInput()
    {
        //Remover MyInput
        //O script vai ser chamado por meio de outra variavel que vai ser executada dentro do call
        //Aqui vai ter a variavel de shooting normal e outra pra verificar se pode ficar atirando direto
        //!!!!!Se poder ficar atirando direto habilita o bool no Update echama direto
        //
        //Ao inv�s disso, fazer sempre chamar o tiro pela anima��o e oq atira direto, o loop da anima��o chamaria o tiro repetidas vezes
        //
        //Verifique se � permitido manter pressionado o bot�o e obter a entrada correspondente
        /*if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);*/

        //Shooting
        if (readyToShoot && shooting && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    public void CallShoot()
    {
        if (readyToShoot && shooting && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Encontre a posi��o exata do hit usando um raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        RaycastHit hit;

        //verifique se o raio atinge algo
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Apenas um ponto longe do jogador

        //Calcule a dire��o do attackPoint ao targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calcule a dispers�o
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calcular nova dire��o com dispers�o
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);/*Granada*/

        //Instanciar flash da arma, se tiver um
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        //Invoque a fun��o resetShot (se ainda n�o tiver sido invocada), com seu timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //se mais de um bulletsPerTap certifique-se de repetir a fun��o de tiro
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        //Permitir atirar e invocar novamente
        readyToShoot = true;
        allowInvoke = true;
    }
}
