﻿using System.Net;
using System.Web.Http;
using AutoMapper;
using Structure.Model;
using Structure.Services.IServices;
using Structure.Web.ViewModels;

namespace Structure.Web.Controllers
{
    public class GadgetsController : System.Web.Http.ApiController
    {
        private readonly IGadgetService _gadgetService;
        private readonly IMapper _mapper;

        public GadgetsController(IGadgetService gadgetService, IMapper mapper)
        {
            _gadgetService = gadgetService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/Gadgets")]
        public IHttpActionResult GetGadgets()
        {
            return Ok(_gadgetService.GetGadgets());
        }

        public IHttpActionResult GetGadget(int id)
        {
            GadgetViewModel vm = null;
            Gadget domain = null;

            domain = _gadgetService.GetGadget(id);

            if (domain == null)
            {
                return NotFound();
            }

            vm = _mapper.Map<Gadget, GadgetViewModel>(domain);

            return Ok(vm);

        }

        public IHttpActionResult PutGadget(int id, GadgetViewModel vm)
        {
            Gadget domain = null;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != vm.GadgetID)
            {
                return BadRequest();
            }
            if (_gadgetService.Exixts(id))
            {
                return NotFound();
            }


            domain = _mapper.Map<GadgetViewModel, Gadget>(vm);

            _gadgetService.Update(domain);

            return StatusCode(HttpStatusCode.NoContent);

        }

        public IHttpActionResult PostOrder(GadgetViewModel vm)
        {
            Gadget domain = null;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            domain = _mapper.Map<GadgetViewModel, Gadget>(vm);

            _gadgetService.CreateGadget(domain);
            _gadgetService.SaveGadget();

            return CreatedAtRoute("DefaultApi", new { id = domain.GadgetID }, domain);

        }

        public IHttpActionResult DeleteOrder(int id)
        {
            Gadget domain = _gadgetService.GetGadget(id);

            if (domain == null)
            {
                return NotFound();
            }
            _gadgetService.Remove(domain);
            _gadgetService.SaveGadget();

            return Ok();
        }
    }
}
