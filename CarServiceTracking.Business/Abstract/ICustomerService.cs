using CarServiceTracking.Core.DTOs.CustomerDTOs;
using CarServiceTracking.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceTracking.Business.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<List<CustomerListDTO>>> GetAllAsync();
        Task<IDataResult<List<CustomerListDTO>>> GetActiveCustomersAsync();
        Task<IDataResult<List<CustomerListItemDTO>>> GetCustomerListItemsAsync();
        Task<IDataResult<CustomerDetailDTO>> GetByIdAsync(int id);
        Task<IDataResult<CustomerDetailDTO>> CreateAsync(CustomerCreateDTO dto);
        Task<IDataResult<CustomerDetailDTO>> UpdateAsync(CustomerUpdateDTO dto);
        Task<IResult> SoftDeleteAsync(int id);
        Task<IResult> SetActiveAsync(int id, bool isActive);
    }
}
