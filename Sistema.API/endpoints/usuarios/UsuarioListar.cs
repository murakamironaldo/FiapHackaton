﻿using Sistema.Application.Interfaces;

namespace Sistema.API.endpoints.usuarios
{
    public class UsuarioListar
    {
        public static string Template => "/usuarios";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        //[Authorize(Policy = "EmployeePolicy")]
        public static IResult Action(IUsuarioApp usuarioService)
        {
            var usuarios= usuarioService.Listar();
        
            return Results.Ok(usuarios);
        }
    }
}
