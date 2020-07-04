namespace WhatsappConsole
{
    public interface IAgenda
    {
         void Cadastrar(Contato _novoContato);
         void Excluir(Contato _excluirContato);
         void Listar();
    }
}