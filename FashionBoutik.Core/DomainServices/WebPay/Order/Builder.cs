using Webpay.Integration.CONST;

namespace Webpay.Integration.Order
{
    public abstract class Builder<T>
    {
        protected IConfigurationProvider _config;
        protected CountryCode _countryCode;

        protected Builder(IConfigurationProvider config)
        {
            _config = config;
        } 

        public IConfigurationProvider GetConfig()
        {
            return _config;
        }

        public CountryCode GetCountryCode()
        {
            return _countryCode;
        }
        public abstract T SetCountryCode(CountryCode countryCode);
    }

}