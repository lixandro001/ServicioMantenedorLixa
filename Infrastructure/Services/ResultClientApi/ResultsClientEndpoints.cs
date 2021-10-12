using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services.ResultClientApi
{
    class ResultsClientEndpoints
    {
        public class PatientApi
        {
            public static string GetPdfResult() => $"/api/resultados/laboratorio";
        }

    }
}
