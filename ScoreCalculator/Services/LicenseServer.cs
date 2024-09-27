using Flurl;
using Flurl.Http;

using ScoreCalculator.Models.DTO.qifu;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreCalculator.Services
{
    public class LicenseServer
    {
        public async Task<District> CheckLicenseServerAsync()
        {

            try
            {
                var result = await "https://qifu-api.baidubce.com/ip/local/geo/v1/district"
              
                .GetJsonAsync<District>();

                return result;

            }
            catch (Exception ex)
            {

                return null;
            }
        

        }
    }
}
