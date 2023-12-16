
import React from 'react';
import './Product.css'

const Product = (props) => {
    const {name, id , seller,img, price,quantity, stock,ratings} = props.product;
    return (
        <div className = 'product'>
            <img src={img} alt="" />
        </div>
    );
};

export default Product;