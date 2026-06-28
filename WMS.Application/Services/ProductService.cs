using AutoMapper;
using WMS.Application.DTOs;
using WMS.Domain.Interfaces;

namespace WMS.Application.Services
{
    /// <summary>
    /// 商品服务实现，提供商品增删改查和库存预警功能
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// 工作单元，用于操作仓储和事务
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// AutoMapper 映射器，用于实体与 DTO 的转换
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// 构造函数，通过依赖注入获取工作单元和映射器
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="mapper">AutoMapper 映射器</param>
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _unitOfWork.Repository<Domain.Entities.Product>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        /// <inheritdoc />
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Repository<Domain.Entities.Product>().GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        /// <inheritdoc />
        public async Task<ProductDto> CreateAsync(CreateProductRequest request)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);
            await _unitOfWork.Repository<Domain.Entities.Product>().AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        /// <inheritdoc />
        public async Task<ProductDto?> UpdateAsync(int id, UpdateProductRequest request)
        {
            var product = await _unitOfWork.Repository<Domain.Entities.Product>().GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }

            // 将请求 DTO 的属性映射到现有实体
            _mapper.Map(request, product);
            _unitOfWork.Repository<Domain.Entities.Product>().Update(product);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Repository<Domain.Entities.Product>().GetByIdAsync(id);
            if (product == null)
            {
                return false;
            }

            await _unitOfWork.Repository<Domain.Entities.Product>().SoftDeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ProductDto>> GetLowStockProductsAsync()
        {
            var products = await _unitOfWork.Repository<Domain.Entities.Product>()
                .FindAsync(p => p.StockQuantity < p.SafetyStock);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
