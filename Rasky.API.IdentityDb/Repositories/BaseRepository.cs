using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Rasky.API.IdentityDb {
    public class BaseRepository<T> : IBaseRepository<T> where T : class,IEntity<T> {
        public readonly AppUserDbContext dbContext;
        public BaseRepository (AppUserDbContext dbContext) {
            this.dbContext = dbContext;
        }
        public IQueryable<T> FindAll () {
            return this.dbContext.Set<T> ();
        }
        public IQueryable<T> FindByCondition (Expression<Func<T, bool>> expression) {
            return this.dbContext.Set<T> ().Where (expression);

        }
        public async Task Create (T entity) {
            await this.dbContext.Set<T> ().AddAsync (entity);
        }
        
        public void Update (T entity) {
            this.dbContext.Set<T> ().Update (entity);

        }

        public void Delete (T entity) {
            this.dbContext.Set<T> ().Remove (entity);

        }
        public async Task<T> FindById(string Id){
            return await this.dbContext.Set<T>().FirstOrDefaultAsync(x=>x.Id==Id);
        }
        public void SetEntityState(T entity, EntityState state){
            this.dbContext.Entry(entity).State=state ;  
        }
    }
}