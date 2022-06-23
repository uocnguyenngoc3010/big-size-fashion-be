﻿using AutoMapper;
using BigSizeFashion.Business.Dtos.Parameters;
using BigSizeFashion.Business.Dtos.Requests;
using BigSizeFashion.Business.Dtos.Responses;
using BigSizeFashion.Business.Helpers.Common;
using BigSizeFashion.Business.Helpers.Constants;
using BigSizeFashion.Business.Helpers.Enums;
using BigSizeFashion.Business.Helpers.ResponseObjects;
using BigSizeFashion.Business.IServices;
using BigSizeFashion.Data.Entities;
using BigSizeFashion.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSizeFashion.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        private readonly IGenericRepository<staff> _staffRepository;
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IGenericRepository<StoreWarehouse> _storeWarehouseRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductImage> _productImageRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public OrderService(IGenericRepository<Order> orderRepository,
            IGenericRepository<OrderDetail> orderDetailRepository,
            IGenericRepository<staff> staffRepository,
            IGenericRepository<Customer> customerRepository,
            IGenericRepository<StoreWarehouse> storeWarehouseRepository,
            IGenericRepository<Product> productRepository,
            IGenericRepository<ProductImage> productImageRepository,
            IProductService productService,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _staffRepository = staffRepository;
            _customerRepository = customerRepository;
            _storeWarehouseRepository = storeWarehouseRepository;
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _productService = productService;
            _mapper = mapper;
        }

        //public async Task<Result<OrderIdResponse>> CreateOrderForCustomer(string token, CreateOrderForCustomerRequest request)
        //{
        //    var result = new Result<OrderIdResponse>();
        //    try
        //    {
        //        var staffUid = DecodeToken.DecodeTokenToGetUid(token);
        //        var staff = await _staffRepository.FindAsync(s => s.Uid == staffUid);
        //        var customer = await _customerRepository.FindAsync(c => c.PhoneNumber.Equals(request.CustomerPhoneNumber));
        //        if(customer == null)
        //        {
        //            result.Error = ErrorHelpers.PopulateError(400, APITypeConstants.BadRequest_400, ErrorMessageConstants.NotExistedUser);
        //            return result;
        //        }

        //        decimal totalPrice = 0;
        //        decimal? totalDiscount = 0;

        //        foreach (var item in request.ListProduct)
        //        {
        //            var p = await _productService.GetProductPrice(item.ProductId);
        //            var dp = await _productService.GetProductPromotionPrice(item.ProductId);

        //            totalPrice += p * item.Quantity;
                    
        //            if (dp != null)
        //            {
        //                totalDiscount += dp * item.Quantity;
        //            }
        //            else
        //            {
        //                totalDiscount += p * item.Quantity;
        //            }

        //            var storeWarehouse = await _storeWarehouseRepository.FindAsync(s => s.StoreId == staff.StoreId && s.ProductId == item.ProductId);
        //            storeWarehouse.Quantity -= item.Quantity;
        //            await _storeWarehouseRepository.UpdateAsync(storeWarehouse);
        //        }

        //        var order = new Order {
        //            CustomerId = customer.Uid,
        //            StoreId = staff.StoreId,
        //            StaffId = staff.Uid,
        //            CreateDate = DateTime.UtcNow.AddHours(7),
        //            TotalPrice = totalPrice,
        //            TotalPriceAfterDiscount = totalDiscount,
        //            OrderType = false,
        //            PaymentMethod = request.PaymentMethod,
        //            ReceivedDate = DateTime.UtcNow.AddHours(7),
        //            Status = (byte)OrderStatusEnum.Received
        //        };
        //        await _orderRepository.InsertAsync(order);
        //        await _orderRepository.SaveAsync();

        //        foreach (var item in request.ListProduct)
        //        {
        //            var od = new OrderDetail
        //            {
        //                OrderId = order.OrderId,
        //                ProductId = item.ProductId,
        //                Quantity = item.Quantity,
        //                Price = await _productService.GetProductPrice(item.ProductId) * item.Quantity,
        //                DiscountPrice = await _productService.GetProductPromotionPrice(item.ProductId) * item.Quantity
        //            };
        //            await _orderDetailRepository.InsertAsync(od);
        //        }
        //        await _orderDetailRepository.SaveAsync();
        //        result.Content = new OrderIdResponse { OrderId = order.OrderId};
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Error = ErrorHelpers.PopulateError(400, APITypeConstants.BadRequest_400, ex.Message);
        //        return result;
        //    }
        //}

        ////public Task<PagedResult<ListOrderResponse>> GetListOrderForCustomer(string token, FilterOrderParameter param)
        ////{
        ////    try
        ////    {

        ////    }
        ////    catch (Exception)
        ////    {

        ////        throw;
        ////    }
        ////}

        //public async Task<Result<GetOrderDetailResponse>> GetOrderDetailById(int id)
        //{
        //    var result = new Result<GetOrderDetailResponse>();
        //    try
        //    {
        //        var order = await _orderRepository.GetAllByIQueryable()
        //                        .Where(o => o.OrderId == id)
        //                        .Include(o => o.Customer)
        //                        .Include(o => o.Staff)
        //                        .Include(o => o.DeliveryAddressNavigation)
        //                        .Include(o => o.Store)
        //                        .Include(o => o.OrderDetails)
        //                        .FirstOrDefaultAsync();
        //        if(order == null)
        //        {
        //            result.Error = ErrorHelpers.PopulateError(400, APITypeConstants.BadRequest_400, ErrorMessageConstants.NotExistedOrder);
        //            return result;
        //        }
        //        var response = _mapper.Map<GetOrderDetailResponse>(order);
        //        response.DeliveryAddress = _mapper.Map<DeliveryAddressResponse>(order.DeliveryAddressNavigation);
        //        response.Store = _mapper.Map<StoreResponse>(order.Store);
        //        response.ProductList = _mapper.Map<List<OrderDetailItem>>(order.OrderDetails);

        //        for (int i = 0; i < response.ProductList.Count; i++)
        //        {
        //            var product = await _productRepository.GetAllByIQueryable()
        //                                .Where(p => p.ProductId == response.ProductList[i].ProductId)
        //                                .Include(p => p.Category)
        //                                .Include(p => p.Colour)
        //                                .Include(p => p.Size)
        //                                .FirstOrDefaultAsync();
        //            response.ProductList[i].ProductName = product.ProductName;
        //            response.ProductList[i].Category = product.Category.CategoryName;
        //            response.ProductList[i].Colour = product.Colour.ColourName;
        //            response.ProductList[i].Size = product.Size.SizeName;
        //            var imageUrl = await _productImageRepository.GetAllByIQueryable()
        //                .Where(p => p.ProductId == response.ProductList[i].ProductId && p.IsMainImage == true)
        //                .Select(p => p.ImageUrl)
        //                .FirstOrDefaultAsync();
        //            if(imageUrl == null)
        //            {
        //                response.ProductList[i].ProductImageUrl = CommonConstants.NoImageUrl;
        //            }
        //            else
        //            {
        //                response.ProductList[i].ProductImageUrl = imageUrl;
        //            }
        //        }
        //        result.Content = response;
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Error = ErrorHelpers.PopulateError(400, APITypeConstants.BadRequest_400, ex.Message);
        //        return result;
        //    }
        //}
    }
}