using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
    public static class MessagesHelper
    {
        public static string NotEmpty(string property) => $"El valor de la propiedad '{ property }' no es puede ser vacío";
        public static string MaximumLength(string property, int size) => $"La propiedad '{ property }' tiene como maximo { size } caracter(es)";
        public static string MinimumLength(string property, int size) => $"La propiedad '{ property }' tiene como minimo { size } caracter(es)";
        public static string Length(string property, int size) => $"La propiedad '{ property }' debe tener { size } caracter(es)";
        public static string IsInEnum(string property) => $"El valor de la propiedad '{ property }' no es válido";
    }
}
