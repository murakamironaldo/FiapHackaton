using Sistema.Application.Interfaces;

namespace Sistema.API.endpoints.usuarios
{
    public class UsuarioExcluir
    {
        public static string Template => "/usuarios/{id}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

      
        public static IResult Action(IUsuarioApp usuarioService, Guid id)
        {
            try
            {
                usuarioService.Excluir(id);
                return Results.Ok("Usuário excluído com sucesso");
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
            
        }
    }
}
