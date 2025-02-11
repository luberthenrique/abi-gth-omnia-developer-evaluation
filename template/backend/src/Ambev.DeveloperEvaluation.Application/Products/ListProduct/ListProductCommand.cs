﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct
{
    /// <summary>
    /// Command for retrieving a product list
    /// </summary>
    public class ListProductCommand : IRequest<ListProductResult>
    {
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of ListProductCommand
        /// </summary>
        /// <param name="name">The name of the product to retrieve</param>
        public ListProductCommand(string name)
        {
            Name = name;
        }
    }
}
