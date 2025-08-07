using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private SaveGame saveGame;
    [SerializeField] private GameObject continuaButton;
    [SerializeField] private Vector3 localCheckPoint;
    [Header("Som do Button")]
    [SerializeField] private AudioClip som;
    private SistemaDeAudio sAudio;


    private void Awake()
    {
        if (saveGame.VerificarSaveGame("Fase1") && continuaButton != null || saveGame.VerificarSaveCheckPoint("Fase1") && continuaButton != null)
        {
            continuaButton.GetComponent<Button>().interactable = true;
        }

        sAudio = FindAnyObjectByType<SistemaDeAudio>();
    }

    public void MudarFase(string nome)
    {
        TocarSomBotao();
        if (sAudio != null)
        {
            sAudio.PlaySoundEffects(som);
        }
        SceneManager.LoadScene(nome);
    }

    public void SalvarFase()
    {
        TocarSomBotao();
        if (saveGame != null)
        {
            saveGame.SalvarJogo(SceneManager.GetActiveScene().name, 0f);
            Debug.Log("Fase salva com sucesso.");
        }
        else
        {
            Debug.LogError("SaveGame não está atribuído.");
        }
    }

    public void SalvarCheckpoint()
    {

        TocarSomBotao(); 
        if (saveGame != null)
        {
            saveGame.SalvarCheckpoint(SceneManager.GetActiveScene().name, 100f, localCheckPoint);
            Debug.Log("Fase salva com sucesso, no checkpoint.");
        }
        else
        {
            Debug.LogError("SaveGame não está atribuído.");
        }
    }

    public void NovoJogo()
    {
        TocarSomBotao();
        if (saveGame != null)
        {
            saveGame.ResetarSave();
        }
    }

    IEnumerator TocarSomBotao()
    {
        yield return new WaitForSeconds(0.5f);

        if(sAudio !=null)
        {
          sAudio.PlaySoundEffects(som);
         }
}     
}
