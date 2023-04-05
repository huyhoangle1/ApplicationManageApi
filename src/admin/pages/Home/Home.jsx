import React from 'react'
import Header from 'admin/components/Header'
import Footer from 'admin/components/Footer'
import SideMenu from 'admin/components/SideMenu'
import { Space } from 'antd'

const Home = () => {
  return (
    <>
      <Header />
      <Space  className='side-menu-and-page-content' >
        <SideMenu />     
      </Space>
      <Footer />
    </>
  )
}

export default Home