/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from "react";
import "./Shop.css";
import Product from "../Product/Product";

const Shop = () => {
    let selectedItem = 0;
  const [products, setProducts] = useState([]);

  useEffect(() => {
    fetch("products.json")
      .then((res) => res.json())
      .then((data) => setProducts(data));
  }, []);
  
  const [cart, setCart] = useState([]);



  // const totalItem=(props)=>{

  //    document.getElementById('items').innerHTML = "Selected Item: "+ props
  // }

  const handleAddToCart = (product) => {

    const newCart = [...cart, product];
    setCart(newCart);
    // selectedItem = selectedItem + 1;
    // totalItem(selectedItem);
  };

 
  return (
    <div className="shop-container">
      <div className="products-container">

        {console.log(products)}
        {products.map((product) => (
          <Product key={product.id} 
          product={product}
          handleAddToCart={handleAddToCart}
          ></Product>
        ))}
      </div>
      <div className="cart-container">
        <h2>Order Summary</h2>
        <p >Selected Items: {cart.length}</p>
      </div>
    </div>
  );
};

export default Shop;
