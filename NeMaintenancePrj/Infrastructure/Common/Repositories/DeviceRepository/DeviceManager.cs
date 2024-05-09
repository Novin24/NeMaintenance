using Domain.MaintainEntity.Devices;
using Infrastructure.EntityFramework;
using NeApplication.IRepositoryies;

namespace Infrastructure.Repositories
{
    public class DeviceManager(NovinDbContext context) : Repository<Device>(context), IDeviceManager
    {
      
    }
}
