# Camera-Cea - Sistema de follow de cámara [![Unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)](https://unity.com/es)

Quinta consigna . curso coderhouse: Desarrollo de videojuegos, clase Cámaras e integración de assets al Engine , Seguimiento de cámaras

## Consigna

Se dede realizar una escena que incluya 

- Elementos de sonido (Al menos 3), texturas (al menos 3), modelos 3D (al menos 3)
- Deben estar importados y configurados correctamente

## Desarrollo de actividad

- Generé una escena completamente nueva, es un repositorio diferente, se requirió debido a las solicitudes de la consigna. La escena anterior no era compatible con los requerimientos debido al tipo de jugabilidad
- Se incluyeron 3 clips de sonido correspondiente a música, que son manejados mediante un script que permite cambiar a gusto e indica que clip está sonando.
- Se genero un escenario tipo mundo abierto, con dos cámaras, una de tercera persona y una tipo topdown Final Fantasy (cuando uno salía al mapa mundial), manejadas mediante script. El script no es mío, así que dejo los créditos correspondientes // Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
- Se incluyeron animaciones al personaje y un método CharacterController utilizando el inputSystem por defecto de unity


- Los metodos agregados separados por script son: 
    - AudioSourceController.cs : 

    ```c
             if (Input.GetKeyDown(KeyCode.O))
        {
             if(index > 0){
                index--;
            }
           
            audioSource.clip = somemp3[index];
            Debug.Log("Song playing: " + audioSource.clip.ToString());
            audioSource.pitch = .8f;
            audioSource.Play();
            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(index <2){
                index++;
            }
            
           
            audioSource.clip = somemp3[index];
            Debug.Log("Song playing: " + audioSource.clip.ToString());
            audioSource.pitch = .8f;
            audioSource.Play();
        }

    ```

    - BleetankController.cs: Se añadieron variables señaladas con barrel (El barril es la zona donde se introduce la bala en un arma) en este caso, misiles o torpedos.
        ```c

            Move();
            Rotate();
            Jump();

            void Move(){

                float vertical = Input.GetAxis ("Vertical");

                Vector3 move = new Vector3(0, 0, vertical);
                bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
                bool isWalking = hasVerticalInput;
                bool isRunning = hasVerticalInput;

                if(vertical > 0){
                    controller.Move(transform.forward * Time.deltaTime * playerSpeed);
                    playerSpeed = 2.0f;
                    m_Animator.SetBool ("isWalking", isWalking);
                } else if (vertical < 0){
                    controller.Move(-transform.forward * Time.deltaTime * playerSpeed);
                    playerSpeed = 1.3f;
                    m_Animator.SetBool ("isWalkingBackwards", isWalking);

                }

            }


        ```

        - CamController.cs: Se añadieron variables señaladas con barrel (El barril es la zona donde se introduce la bala en un arma) en este caso, misiles o torpedos.
        ```c

            // activar o desactivar camaras
            if (Input.GetKey(KeyCode.F1))
            {
                if (!thirdpersonenabled)
                {
                    cameras[0].SetActive(true);
                    cameras[1].SetActive(false);
                }
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                if (!topdownenabled)
                {
                    cameras[0].SetActive(false);
                    cameras[1].SetActive(true);
                }
            }


        ```

- Las animaciones están en desarrollo, debido a que no tengo mucho conocimiento con state machines de multiples capas, para animaciones en simultaneo
## Autor

- [@Josue Cea](https://www.github.com/Nifrith)

