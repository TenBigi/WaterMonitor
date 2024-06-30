using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WaterMonitor.Data.Model;
using WaterMonitor.Data;
using System;

namespace WaterMonitor.Pages.ConfigurationPages
{
    public class TokenConfigModel : GenericPageModel
    {
        [BindProperty]
        public string GeneratedToken { get; set; }

        public TokenConfigModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AuthorizationToken> LastTenTokens = new();

        public async Task<IActionResult> OnGetAsync()
        {
            LastTenTokens = await _context.Tokens.OrderByDescending(t => t.CreatedAt).Take(10).ToListAsync();
            
            return Page();
        }

        public async Task<IActionResult> OnPostGenerateTokenAsync()
        {
            ModelState.Remove("GeneratedToken");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }

            var token = Guid.NewGuid().ToString();
            var tokenModel = new AuthorizationToken
            {
                Token = token,
                CreatedAt = DateTime.Now
            };

            _context.Tokens.Add(tokenModel);
            await _context.SaveChangesAsync();

            GeneratedToken = token;

            LastTenTokens = await _context.Tokens.OrderByDescending(t => t.CreatedAt).Take(10).ToListAsync();
            return Page();
        }
    }
}
