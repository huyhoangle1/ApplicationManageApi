import React from 'react'
import 'App.css'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

import Dashboard from 'admin/pages/Dashboard/Dashboard'
import Order from 'admin/pages/Order/Order'
import Category from 'admin/pages/Category/Category'
import Product from 'admin/pages/Product/Product'
import Producer from 'admin/pages/Producer/Producer'
import Discount from 'admin/pages/Discount/Discount'
import Customer from 'admin/pages/Customer/Customer'
import User from 'admin/pages/User/User'
import CreateCategory from 'admin/pages/Category/CreateCategory'
import CreateProduct from 'admin/pages/Product/CreateProduct'
import CreateProducer from 'admin/pages/Producer/CreateProducer'
import CreateDiscount from 'admin/pages/Discount/CreateDiscount'
import CreateCustomer from 'admin/pages/Customer/CreateCustomer'
import CreateUser from 'admin/pages/User/CreateUser'
import UpdateProduct from 'admin/pages/Product/UpdateProduct'
import ViewOrder from 'admin/pages/Order/ViewOrder'


const App = () => {
  return (
    <div className='App'>
      <Router>
        <Routes>
            <Route path="/admin" exact element={<Dashboard />} />
            <Route path="/admin/order" exact element={<Order />} />
            <Route path="/admin/order/view/:id" exact element={<ViewOrder />} />
            <Route path="/admin/category" exact element={<Category />} />
            <Route path="/admin/category/create" exact element={<CreateCategory />} />
            <Route path="/admin/product" exact element={<Product />} />
            <Route path="/admin/product/create" exact element={<CreateProduct />} />
            <Route path="/admin/product/update/:id" exact element={<UpdateProduct />} />
            <Route path="/admin/producer" exact element={<Producer />} />
            <Route path="/admin/producer/create" exact element={<CreateProducer />} />
            <Route path="/admin/discount" exact element={<Discount />} />
            <Route path="/admin/discount/create" exact element={<CreateDiscount />} />
            <Route path="/admin/customer" exact element={<Customer />} />
            <Route path="/admin/customer/create" exact element={<CreateCustomer />} />
            <Route path="/admin/user" exact element={<User />} />
            <Route path="/admin/user/create" exact element={<CreateUser />} />
        </Routes>
      </Router>
    </div>
  )
}

export default App