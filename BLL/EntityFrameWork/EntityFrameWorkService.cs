using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityFrameWork
{
    public class EntityFrameWorkService
    {
        //private readonly FasterDbContext _dbContext;

        //public EntityFrameWorkService(FasterDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //#region Genaric Add
        ////Employee employee = await _employeeRepository.AddEntity(emp);
        //public async Task<T> AddEntity<T>(T newEntity) where T : class
        //{
        //    await _dbContext.Set<T>().AddAsync(newEntity);
        //    await _dbContext.SaveChangesAsync();
        //    return newEntity;
        //}
        //#endregion

        //#region Genaric Add Range Entity Items
        ////List<Employee> employeeList = await _employeeRepository.AddEntityList(empList);
        //public async Task<List<T>> AddEntityList<T>(List<T> entityListToAdd) where T : class
        //{
        //    await _dbContext.Set<T>().AddRangeAsync(entityListToAdd);
        //    await _dbContext.SaveChangesAsync();
        //    return entityListToAdd;
        //}
        //#endregion

        //#region Genaric Update
        ////Employee employeeToUpdate = await _employeeRepository.UpdateEntity(emp);
        //public async Task<T> UpdateEntity<T>(T entityToUpdate) where T : class
        //{
        //    var entity = _dbContext.Set<T>().Attach(entityToUpdate);
        //    entity.State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();
        //    return entityToUpdate;
        //}
        //#endregion

        //#region Genaric Remove One Entity Item
        ////bool isDeleted = await _employeeRepository.DeleteEntity(emp);
        //public async Task<bool> DeleteEntity<T>(T entityToDelete) where T : class
        //{
        //    _dbContext.Set<T>().Remove(entityToDelete);
        //    int result = await _dbContext.SaveChangesAsync();
        //    if (result <= 0)
        //        return false;
        //    else
        //        return true;
        //}
        //#endregion

        //#region Genaric Remove Range Entity Items
        ////bool isDeleted = await _employeeRepository.DeleteEntityList(empList);
        //public async Task<bool> DeleteEntityList<T>(List<T> entityListToDelete) where T : class
        //{
        //    _dbContext.Set<T>().RemoveRange(entityListToDelete);
        //    int result = await _dbContext.SaveChangesAsync();
        //    if (result <= 0)
        //        return false;
        //    else
        //        return true;
        //}
        //#endregion
    }
}
