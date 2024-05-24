using EShop.Domain.Contract.Setting;

namespace EShop.Api.Setting
{
    public class AppSetting: IAppSetting
    {
        private IConfigurationBuilder configuration;
        public AppSetting()
        {
            this.configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = this.configuration.Build();
            configuration.GetSection("AppSetting").Bind(this);
        }

        public string ConnectionString { get; set; }
    }
}
