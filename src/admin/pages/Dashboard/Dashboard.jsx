/* eslint-disable max-classes-per-file */
import { DropboxOutlined, HighlightOutlined, MailOutlined, SkinOutlined } from '@ant-design/icons';
import Header from 'admin/components/Header';
import SideMenu from 'admin/components/SideMenu';
import Title from 'antd/es/typography/Title';
import { Typography } from 'antd';
import React, { useEffect, useState } from 'react';
import { Line } from '@ant-design/plots';

const Dashboard = () => {
  const [data, setData] = useState([]);

  useEffect(() => {
    asyncFetch();
  }, []);

  const asyncFetch = () => {
    fetch('https://gw.alipayobjects.com/os/bmw-prod/1d565782-dde4-4bb6-8946-ea6a38ccf184.json')
      .then((response) => response.json())
      .then((json) => setData(json))
      .catch((error) => {
        console.log('fetch data failed', error);
      });
  };
  const config = {
    data,
    padding: 'auto',
    xField: 'Date',
    yField: 'scales',
    xAxis: {
      tickCount: 5,
    },
    slider: {
      start: 0.1,
      end: 0.5,
    },
  };
  return (
    <>
      <div style={{ display: 'flex', overflowY: 'scroll'}}>
        <SideMenu />
        <div style={{ overflowY: 'scroll'}}>
          <Header />
          <div style={{ background: '#e6e6e6', display: 'flex', padding: '15px 15px 70px', justifyContent: 'space-around'}}>
            <div>
              <div style={{ background: '#33adff', width: '250px', display: 'flex', padding: '15px', justifyContent: 'space-between'}}>
                <div style={{ padding: '10px 0 10px 10px'}}>
                  <Title level={3} style={{ color: 'white',  textAlign: 'center'}}>22</Title>
                  <Typography style={{ color: 'white', fontSize: '12px'}}>Sản Phẩm</Typography>
                </div>
                <SkinOutlined style={{ color: 'rgba(0, 0, 0, 0.4)' , fontSize: 60, padding: '10px 10px 10px 0'}} />
              </div>
              <Typography style={{ backgroundColor: '#0099ff' ,color: 'white', textAlign: 'center'}}>Danh sách sản phẩm</Typography>
            </div>
            <div>
              <div style={{ background: '#00cc44', width: '250px', display: 'flex', padding: '15px', justifyContent: 'space-between'}}>
                <div style={{ padding: '10px 0 10px 10px'}}>
                  <Title level={3} style={{ color: 'white',  textAlign: 'center'}}>3</Title>
                  <Typography style={{ color: 'white', fontSize: '12px'}}>Bài Viết</Typography>
                </div>
                <HighlightOutlined style={{ color: 'rgba(0, 0, 0, 0.4)' , fontSize: 60, padding: '10px 10px 10px 0'}} />
              </div>
              <Typography style={{ backgroundColor: '#009933' ,color: 'white', textAlign: 'center'}}>Danh sách Bài Viết</Typography>
            </div>
            <div>
              <div style={{ background: '#cccccc', width: '250px', display: 'flex', padding: '15px', justifyContent: 'space-between'}}>
                <div style={{ padding: '10px 0 10px 10px'}}>
                  <Title level={3} style={{ color: 'white',  textAlign: 'center'}}>229</Title>
                  <Typography style={{ color: 'white', fontSize: '12px'}}>Liên Hệ</Typography>
                </div>
                <MailOutlined style={{ color: 'rgba(0, 0, 0, 0.4)' , fontSize: 60, padding: '10px 10px 10px 0'}} />
              </div>
              <Typography style={{ backgroundColor: '#999999' ,color: 'white', textAlign: 'center'}}>Liên hệ Khách hàng</Typography>
            </div>
            <div>
              <div style={{ background: '#ff0000', width: '250px', display: 'flex', padding: '15px', justifyContent: 'space-between'}}>
                <div style={{ padding: '10px 0 10px 10px'}}>
                  <Title level={3} style={{ color: 'white',  textAlign: 'center'}}>38</Title>
                  <Typography style={{ color: 'white', fontSize: '12px'}}>Đơn Hàng</Typography>
                </div>
                <DropboxOutlined style={{ color: 'rgba(0, 0, 0, 0.4)' , fontSize: 60, padding: '10px 10px 10px 0'}} />
              </div>
              <Typography style={{ backgroundColor: '#b30000' ,color: 'white', textAlign: 'center'}}>Danh sách đơn hàng</Typography>
            </div>
          </div>
          <div style={{ borderTop: '3px solid cyan'}}>
            <div style={{ display: 'flex', justifyContent: 'space-between', margin: '0 10px' }}>
              <Typography.Title level={3} style={{ marginTop: '10px', color: '#555555'}}>Bán hàng & Doanh Thu</Typography.Title>
              <Typography.Title level={5} style={{ color: 'red'}}>Doanh thu hôm nay: 0 VND</Typography.Title>
            </div>
            <div><Line {...config} /> </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default Dashboard;
