using Sistema.Application.Interfaces;

namespace Sistema.API.endpoints.usuarioperfis
{
    public class UsuarioPerfisListar
    {
        public static string Template => "/usuarioperfil";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        //[Authorize(Policy = "EmployeePolicy")]
        public static IResult Action(IUsuarioPerfilApp usuarioPerfilApp)
        {
            var lista= usuarioPerfilApp.Listar();
        
            return Results.Ok(lista);
        }
    }
}
