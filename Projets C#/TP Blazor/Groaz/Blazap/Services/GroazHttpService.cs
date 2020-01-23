using Blazap.DTOs;
using Blazap.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazap.Services
{
    public class GroazHttpService : IGroazService
    {
        private HttpClient httpClient;

        public GroazHttpService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Groaz> getDetails(Guid id)
        {
            var dto = await this.httpClient
                    .GetJsonAsync<GroazDTO>("https://localhost:44323/Groaz/" + id.ToString());
            return new Groaz()
            {
                Id = dto.i,
                Trut = dto.t,
                DateNaissance = dto.dn,
                NiveauDeBins = dto.nb,
                IdParain = dto.ip
            };
        }

        public async Task<IEnumerable<Groaz>> getGroazSet()
        {
            var tabTDOs = await this.httpClient
             .GetJsonAsync<GroazItemDTO[]>("https://localhost:44323/Groaz");
            return  tabTDOs.Select(dto => new Groaz() { Id = dto.i, Trut = dto.t });

        }
    }
}
