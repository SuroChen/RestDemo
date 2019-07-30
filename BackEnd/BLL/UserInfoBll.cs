using BackEnd.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.BLL
{
    public class UserInfoBll
    {
        RestDemoEntities context = new RestDemoEntities();
        
        public async Task<List<UserInfo>> getUserInfoes()
        {
            return await context.UserInfoes.ToListAsync();
        }
        
        public async Task<UserInfo> getUserInfoByID(int id)
        {
            return await context.UserInfoes.Where(x => x.id == id).FirstAsync();
        }
        
        public async Task<bool> addUserInfo(UserInfo obj)
        {
            try
            {
                context.UserInfoes.Add(obj);
                await SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> destroyUserInfo(int id)
        {
            UserInfo obj = await context.UserInfoes.FindAsync(id);
            if (obj == null)
            {
                return false;
            }
            context.UserInfoes.Remove(obj);
            try
            {
                await SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> modifyUserInfo(UserInfo obj)
        {
            try
            {
                context.Entry(obj).State = EntityState.Modified;
                await SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(obj.id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        #region "Private Methods"
        private bool UserInfoExists(int id)
        {
            return context.UserInfoes.Count(a => a.id == id) > 0;
        }
        private void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (OptimisticConcurrencyException ocex)
            {
                throw ocex;
            }
        }
        private async Task<int> SaveChangesAsync()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (OptimisticConcurrencyException ocex)
            {
                throw ocex;
            }
        }
        #endregion
    }
}
