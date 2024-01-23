

namespace BookLinks.Rest.Api
{
    //проверить файл нужное оставить ненужное убрать
    public class ApiSettings /* : BookLinksSettings*/
    {
        public string[] AllowedOrigins { get; set; }

        public JwtSettings Auth { get; set; }

        public HangfireDashboardSettings HangfireDashboard { get; set; }

        public class JwtSettings
        {
            public string Secret { get; set; }

            public int TokenExpireMinutes { get; set; }

            public int RefreshExpiresDays { get; set; }

            public string Issuer { get; set; }

            public string Audience { get; set; }
        }

        public class HangfireDashboardSettings
        {
            public string Username { get; set; }

            public string Password { get; set; }
        }
    }
}
