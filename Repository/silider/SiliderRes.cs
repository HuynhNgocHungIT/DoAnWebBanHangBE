﻿using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.silider
{
    public class SiliderRes : ISilider
    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public SiliderRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddSliderAsync(SliderModel Slider)
        {
            var newSlider = _mapper.Map<Slider>(Slider);
            _context.Sliders.Add(newSlider);
            await _context.SaveChangesAsync();
            return newSlider.Id;
        }

        public async Task<List<SliderModel>> GetAllSliderAsync()
        {
            var SliderList = await _context.Sliders.ToListAsync();
            return _mapper.Map<List<SliderModel>>(SliderList);
        }

        public async Task<SliderModel> GetSliderAsync(int id)
        {
            var resultDetailSlider = await _context.Sliders.FindAsync(id);
            return _mapper.Map<SliderModel>(resultDetailSlider);
        }

        public Task RemoveSliderAllAsync(List<SliderModel> Slider)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveSliderAsync(int id)
        {
            if (id != null)
            {
                var getSilider = await _context.Sliders.FindAsync(id);
                if (getSilider != null)
                {
                    _context.Sliders.Remove(getSilider);
                    await _context.SaveChangesAsync();

                }
            }
        }

        public  async Task UpdateSliderAsync(int id, SliderModel Slider)
        {
            if (id == Slider.Id)
            {
                var updateSilder = _mapper.Map<Slider>(Slider);
                _context.Sliders!.Update(updateSilder);
                await _context.SaveChangesAsync();
            }
        }
    }
}
