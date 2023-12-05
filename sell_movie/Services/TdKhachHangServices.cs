using AutoMapper;
using NuGet.Protocol.Core.Types;
using sell_movie.Enities;
using sell_movie.Models;
using sell_movie.Repository;

public interface ITdKhachHangService
{
    Task<IEnumerable<TdKhachHangModels>> GetAllTdKhachHangs();
    Task<TdKhachHangModels> GetTdKhachHangById(string id);
    Task CreateTdKhachHang(TdKhachHangModels tdKhachHangModels);
    Task UpdateTdKhachHang(string id, TdKhachHangModels tdKhachHangModels);
    Task DeleteTdKhachHang(string id);
}

public class TdKhachHangService : ITdKhachHangService
{
    private readonly MyRepository<Tdkhachhang> _tdKhachHangRepository;
    private readonly IMapper _mapper;

    public TdKhachHangService(MyRepository<Tdkhachhang> tdKhachHangRepository, IMapper mapper)
    {
        _tdKhachHangRepository = tdKhachHangRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TdKhachHangModels>> GetAllTdKhachHangs()
    {
        var tdKhachHangs = await _tdKhachHangRepository.GetAll();
        var tdKhachHangModels = _mapper.Map<IEnumerable<TdKhachHangModels>>(tdKhachHangs);
        return tdKhachHangModels;
    }

    public async Task<TdKhachHangModels> GetTdKhachHangById(string id)
    {
        var tdKhachHang = await _tdKhachHangRepository.GetById(id);
        var tdKhachHangModel = _mapper.Map<TdKhachHangModels>(tdKhachHang);
        return tdKhachHangModel;
    }

    public async Task CreateTdKhachHang(TdKhachHangModels tdKhachHangModels)
    {
        var tdKhachHang = _mapper.Map<Tdkhachhang>(tdKhachHangModels);
        await _tdKhachHangRepository.Create(tdKhachHang);
    }

    public async Task UpdateTdKhachHang(string id, TdKhachHangModels tdKhachHangModels)
    {
        var existingTdKhachHang = await _tdKhachHangRepository.GetById(id);
        if (existingTdKhachHang != null)
        {
            var updatedTdKhachHang = _mapper.Map(tdKhachHangModels, existingTdKhachHang);
            await _tdKhachHangRepository.Update(id, updatedTdKhachHang);
        }
    }

    public async Task DeleteTdKhachHang(string id)
    {
        await _tdKhachHangRepository.Delete(id);
    }
}