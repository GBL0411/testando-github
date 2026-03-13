using UnityEngine;
using UnityEngine.SceneManagement;

//using UnityEngine.InputSystem;
public class TelaInicial : MonoBehaviour
{
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject painelMenuPrincipal;

    private Novoinput ni;

    void Awake()
    {
        ni = new Novoinput();
        //ni.Menu.Back.performed += Voltar;
    }

    public void NovoJogo()
    {
        SceneManager.LoadScene(0);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void AbrirOpcoes()
    {
        painelMenuPrincipal.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void Creditos()
    {
        painelMenuPrincipal.SetActive(false);
        credits.SetActive(true);
        print("Abriu o painel creditos");
    }

    public void Voltar()
    {
        painelMenuPrincipal.SetActive(true);
        credits.SetActive(false);
        painelOpcoes.SetActive(false);
    }
}