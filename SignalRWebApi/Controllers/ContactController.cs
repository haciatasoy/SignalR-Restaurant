﻿using AutoMapper;
using BusinessLayer.Abstract;
using DTOlayer.ContactDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
			return Ok(value);
		}
		[HttpPost]
		public IActionResult CreateContact(CreateContactDto createContactDto)
		{
			var value = _mapper.Map<Contact>(createContactDto);
			_contactService.TAdd(value);
			return Ok("İletişim Bilgisi Eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteContact(int id)
		{
			var value = _contactService.TGetByID(id);
			_contactService.TDelete(value);
			return Ok("İletişim Bilgisi Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetContact(int id)
		{
			var value = _contactService.TGetByID(id);
			return Ok(_mapper.Map<GetByIdContactDto>(value));
		}
		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{
			var value = _mapper.Map<Contact>(updateContactDto);
			_contactService.TUpdate(value);
			return Ok("İletişim Bilgisi Güncellendi");
		}
	}
}
