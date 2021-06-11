using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using crssAssetDV.Models;
using AutoMapper;
using crssAssetDV.Dtos;
using System.Data.Entity;


namespace crssAssetDV.Api
{
    public class DevicesController : ApiController
    {
        private ApplicationDbContext _context;
        
        public DevicesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Device
        public IHttpActionResult GetDevices(string query = null)
        {
            var devicesQuery = _context.Devices
                .Include(c => c.TypeOfDevice)
                .Include(c => c.RoleDevice)
                .Include(c => c.DeviceNote)
                .Include(c => c.DamagedSelectOption);

            if (!String.IsNullOrWhiteSpace(query))
            if (!String.IsNullOrWhiteSpace(query))
                devicesQuery = devicesQuery.Where(c => c.Edquip.Contains(query));

            var deviceDtos = devicesQuery
                .ToList()
                .Select(Mapper.Map<Device, DeviceDto>);

            return Ok(deviceDtos);
        }

        //GET /api/Devices/1
        public IHttpActionResult GetDevice(int id)
        {
            var device = _context.Devices.SingleOrDefault(c => c.Id == id);

            if (device == null)
                return NotFound();
            
            return Ok(Mapper.Map<Device, DeviceDto>(device));
        }

        //POST /api/Devices
        [HttpPost]
        public IHttpActionResult CreateDevice (DeviceDto deviceDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var device = Mapper.Map<DeviceDto, Device>(deviceDto);
            _context.Devices.Add(device);
            _context.SaveChanges();

            deviceDto.Id = device.Id;
            return Created(new Uri(Request.RequestUri + "/" + device.Id), deviceDto);
        }

        //PUT /api/devices/1
        public IHttpActionResult UpdateDevice(int id, DeviceDto deviceDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var deviceInDB = _context.Devices.SingleOrDefault(c => c.Id == id);

            if (deviceInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(deviceDto, deviceInDB);
            
            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/devices/1
        [HttpDelete]
        public IHttpActionResult DeleteDevice(int id)
        {
            var deviceInDb = _context.Devices.SingleOrDefault(c => c.Id == id);

            if (deviceInDb == null)
                return NotFound();

            _context.Devices.Remove(deviceInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
