using Structure.IRepositories;
using Structure.IRepositories.IUnitOfWork;
using Structure.Services.IServices;

namespace Structure.Services
{
    public class GadgetOrderService : IGadgetOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGadetOrderRepository _gadetOrderRepository;

        public GadgetOrderService(IGadetOrderRepository gadetOrderRepository, IUnitOfWork unitOfWork)
        {
            _gadetOrderRepository = gadetOrderRepository;
            _unitOfWork = unitOfWork;
        }
    }
}