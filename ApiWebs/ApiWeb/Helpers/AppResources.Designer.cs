﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiWeb.Helpers {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AppResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ApiWeb.Helpers.AppResources", typeof(AppResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Identificador de cliente es un dato requerido por header..
        /// </summary>
        internal static string ClientCredentialHeaders {
            get {
                return ResourceManager.GetString("ClientCredentialHeaders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El recurso especificado requiere autenticación..
        /// </summary>
        internal static string ErrorAutenticacion {
            get {
                return ResourceManager.GetString("ErrorAutenticacion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No esta autorizado para acceder al recurso. Contacte con el administrador del servicio..
        /// </summary>
        internal static string ErrorAuthorizationRequerido {
            get {
                return ResourceManager.GetString("ErrorAuthorizationRequerido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Excepción producida al procesar la solicitud..
        /// </summary>
        internal static string ErrorExcepcionAplicacion {
            get {
                return ResourceManager.GetString("ErrorExcepcionAplicacion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El recurso especificado requiere especificar el protocolo de seguridad secure sockets layer..
        /// </summary>
        internal static string ErrorServiceSecureHttps {
            get {
                return ResourceManager.GetString("ErrorServiceSecureHttps", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Debe completar los parámetros requeridos..
        /// </summary>
        internal static string TodosParametrosRequerido {
            get {
                return ResourceManager.GetString("TodosParametrosRequerido", resourceCulture);
            }
        }
    }
}
