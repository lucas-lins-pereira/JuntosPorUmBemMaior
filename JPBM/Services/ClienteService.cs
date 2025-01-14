﻿using JPBM.Enums;
using JPBM.Interfaces;
using JPBM.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPBM.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteViewModel>> ListarClientesAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            var clientesViewModel = new List<ClienteViewModel>(clientes.Count);

            foreach (var cliente in clientes)
                clientesViewModel.Add(ClienteViewModel.MapFromEntity(cliente));

            return clientesViewModel;
        }

        public List<ClienteViewModel> ListarVendedores(List<ClienteViewModel> clientes)
        {
            var vendedores = new List<ClienteViewModel>();
            clientes.ForEach(cliente =>
            {
                if (cliente.Vendedor == StatusAtivo.Sim)
                    vendedores.Add(cliente);
            });
            return vendedores;
        }
    }
}
