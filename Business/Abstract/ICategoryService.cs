using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICategoryService
	{
		IDataResult<Category> GetById(int categoryId);
		IDataResult<List<Category>> GetList();
		//IDataResult<List<Category>> GetListByCategory(int categoryId);
		IResult Add(Category product);
		IResult Delete(Category product);
		IResult Update(Category product);
	}
}
