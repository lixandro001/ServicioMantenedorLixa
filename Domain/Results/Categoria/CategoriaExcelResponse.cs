using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Results.Categoria
{
   public class CategoriaExcelResponse
    {    
        [JsonProperty("excel")]
        public byte[] Excel { get; set; }
    }
}
