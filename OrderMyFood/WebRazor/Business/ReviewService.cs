using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OrderMyFood.Web.WebRazor;
using OrderMyFood.Web.WebRazor.Infrastructure;
using OrderMyFood.Web.WebRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.Web.WebRazor.Business
{
    public class ReviewService : IReviewService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;

        public ReviewService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient)
        {
            _settings = settings;
            _apiClient = httpClient;
            _remoteServiceBaseUrl = $"{_settings.Value.ReviewUrl}/api/Review";
        }

        #region
        public async Task<IEnumerable<RatingViewModel>> GetRatings()
        {
            var getBrandsUri = ApiPaths.ReviewPage.GetRestaurantRatings(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(getBrandsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<RatingViewModel>>(dataString);
            return response;
        }
        #endregion
    }
}
