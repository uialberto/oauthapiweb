using Microsoft.Web.Http.Description;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace ApiWeb.Helpers.Swagger
{
    public class ImplicitApiVersionParameter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var description = apiDescription as VersionedApiDescription;
            if (description?.ApiVersion == null)
            {
                return;
            }

            var parameters = operation.parameters;

            if (parameters == null)
            {
                operation.parameters = parameters = new List<Parameter>();
            }
            var parameter = parameters.SingleOrDefault(p => p.name == "version");

            if (parameter == null)
            {
                parameter = new Parameter()
                {
                    name = "version",
                    required = true,
                    @in = "query",
                    type = "string"
                };

                parameters.Add(parameter);
            }
            parameter.@default = description.ApiVersion.ToString();
            parameter.description = "API Version";

            
        }
    }
}