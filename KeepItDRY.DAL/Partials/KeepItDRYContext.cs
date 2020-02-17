using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KeepItDRY.DAL
{
    public partial class KeepItDRYContext
    {
        private string _currentUser = null;

        public string CurrentUser
        {
            get
            {
                if (string.IsNullOrEmpty(_currentUser))
                {
                    _currentUser = (Thread.CurrentPrincipal?.Identity?.Name != null ? Thread.CurrentPrincipal.Identity.Name : Environment.UserName).ToLower().Replace("sherwoodcu\\", "");
                }
                return _currentUser;
            }
            set => _currentUser = value;
        }

        private void SetStandardEntityValues()
        {
            var changes = ChangeTracker.Entries()
                                       .Where(e => e.Entity is IStandardEntity)
                                       .ToList();

            foreach (var e in changes)
            {
                var standardEntity = e.Entity as IStandardEntity;
                switch (e.State)
                {
                    case EntityState.Added:
                        standardEntity.CreatedDate = DateTime.Now;
                        standardEntity.CreatedBy = standardEntity.CreatedBy ?? CurrentUser;
                        standardEntity.LastUpdated = DateTime.Now;
                        standardEntity.LastUpdatedBy = CurrentUser;
                        break;
                    case EntityState.Modified:
                        standardEntity.LastUpdated = DateTime.Now;
                        standardEntity.LastUpdatedBy = CurrentUser;
                        break;
                    default:
                        break;
                }
            }
        }

        public override int SaveChanges()
        {
            SetStandardEntityValues();

            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                throw;
            }
        }
    }
}
