using Business.Services.Abstract;
using Business.ViewModels.About;
using DataAccess.Repositories.Abstract;

namespace Business.Services.Conrete
{
    public class AboutService : IAboutService
    {
        private readonly IFeaturesRepository _featuresRepository;
        private readonly IAboutStoreRepository _aboutStoreRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IInfoRepository _infoRepository;

        public AboutService(IFeaturesRepository featuresRepository,
            IAboutStoreRepository aboutStoreRepository,
            ITeamRepository teamRepository,
            IInfoRepository infoRepository)
        {
            _featuresRepository = featuresRepository;
            _aboutStoreRepository = aboutStoreRepository;
            _teamRepository = teamRepository;
            _infoRepository = infoRepository;
        }
        public async Task<AboutIndexVM> GetAllAsync()
        {
            var model = new AboutIndexVM
            {
                AboutStores = await _aboutStoreRepository.GetAllAsync(),
                Features = await _featuresRepository.GetAllAsync(),
                Infos = await _infoRepository.GetAllAsync(),
                Teams = await _teamRepository.GetAllAsync()
            };
            return model;
        }
    }
}
