using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage; // Mantém-se igual
using Newtonsoft.Json;
using PortalUpskill.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PortalUpskill.App.Data
{
    public class UpskillAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedLocalStorage _localStorage;

        public UpskillAuthenticationStateProvider(ProtectedLocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            Pessoa user = null;

            // 2. Alterado para ler do LocalStorage
            var readUserFromLocal = await _localStorage.GetAsync<string>("user");
            if (readUserFromLocal.Success)
            {
                user = JsonConvert.DeserializeObject<Pessoa>(readUserFromLocal.Value);
            }

            ClaimsIdentity identity;
            if (user != null)
            {
                identity = GetIdentityClaims(user);
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var userClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(userClaimsPrincipal));
        }

        public void MarkUserAsAuthenticated(Pessoa pessoa)
        {
            ClaimsIdentity identity = GetIdentityClaims(pessoa);

            ClaimsPrincipal user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            // 3. Alterado para apagar do LocalStorage
            _localStorage.DeleteAsync("user");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity GetIdentityClaims(Pessoa user)
        {
            return new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Perfil.Nome)
            }, "apiauth_type");
        }
    }
}