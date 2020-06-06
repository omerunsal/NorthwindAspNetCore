using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private ICategoryDal _categoryDal;
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public IResult Add(Category category)
		{
			//Business codes
			_categoryDal.Add(category);
			return new SuccessResult(Messages.CategoryAdded);
		}

		public IResult Delete(Category product)
		{
			_categoryDal.Delete(product);
			return new SuccessResult(Messages.CategoryDeleted);
		}

		public IDataResult<Category> GetById(int productId)
		{
			return new SuccessDataResult<Category>(_categoryDal.Get(filter: p => p.CategoryId == productId));
		}

		public IDataResult<List<Category>> GetList()
		{
			return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
		}

		//public IDataResult<List<Category>> GetListByCategory(int categoryId)
		//{
		//	return new SuccessDataResult<List<Category>>(_categoryDal.GetList(filter: p => p.CategoryId == categoryId).ToList());
		//}

		public IResult Update(Category product)
		{
			_categoryDal.Update(product);
			return new SuccessResult(Messages.CategoryUpdated);
		}

	}
}
