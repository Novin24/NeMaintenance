using Infrastructure.EntityFramework;
using Infrastructure.Repositories;
using NeApplication.IRepositoryies;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        readonly NovinDbContext NovinDb = new();

        private IDeviceManager _deviceManager;

        public IDeviceManager DeviceManager
        {
            get
            {
                if (_deviceManager == null)
                {
                    _deviceManager = new DeviceManager(NovinDb);
                }
                return _deviceManager;
            }
        }

        public async void Dispose() => await NovinDb.DisposeAsync();

        public async Task SaveChangesAsync()
        {
            await NovinDb.SaveChangesAsync();
        }
    }
}
