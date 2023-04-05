import { CheckOutlined, DeleteOutlined, EditOutlined, SearchOutlined, VerticalAlignBottomOutlined, WalletOutlined } from '@ant-design/icons'
import Header from 'admin/components/Header'
import SideMenu from 'admin/components/SideMenu'
import { Typography, Table, Button, Image, Input, Space } from 'antd'
import React, { useState, useRef } from 'react'
import Highlighter from 'react-highlight-words'
import { Link } from 'react-router-dom'


const Category = () => {
  const [selectionType, setSelectionType] = useState('checkbox');
  const [searchText, setSearchText] = useState('');
  const [searchedColumn, setSearchedColumn] = useState('');
  const searchInput = useRef(null);
  const handleSearch = (selectedKeys, confirm, dataIndex) => {
    confirm();
    setSearchText(selectedKeys[0]);
    setSearchedColumn(dataIndex);
  };
  const handleReset = (clearFilters) => {
    clearFilters();
    setSearchText('');
  };
  const getColumnSearchProps = (dataIndex) => ({
    filterDropdown: ({ setSelectedKeys, selectedKeys, confirm, clearFilters, close }) => (
      <div
        style={{
          padding: 8,
        }}
        onKeyDown={(e) => e.stopPropagation()}
      >
        <Input
          ref={searchInput}
          placeholder={`Search ${dataIndex}`}
          value={selectedKeys[0]}
          onChange={(e) => setSelectedKeys(e.target.value ? [e.target.value] : [])}
          onPressEnter={() => handleSearch(selectedKeys, confirm, dataIndex)}
          style={{
            marginBottom: 8,
            display: 'block',
          }}
        />
        <Space>
          <Button
            type="primary"
            onClick={() => handleSearch(selectedKeys, confirm, dataIndex)}
            icon={<SearchOutlined />}
            size="small"
            style={{
              width: 90,
            }}
          >
            Search
          </Button>
          <Button
            onClick={() => clearFilters && handleReset(clearFilters)}
            size="small"
            style={{
              width: 90,
            }}
          >
            Reset
          </Button>
          <Button
            type="link"
            size="small"
            onClick={() => {
              confirm({
                closeDropdown: false,
              });
              setSearchText(selectedKeys[0]);
              setSearchedColumn(dataIndex);
            }}
          >
            Filter
          </Button>
          <Button
            type="link"
            size="small"
            onClick={() => {
              close();
            }}
          >
            close
          </Button>
        </Space>
      </div>
    ),
    filterIcon: (filtered) => (
      <SearchOutlined
        style={{
          color: filtered ? '#1890ff' : undefined,
        }}
      />
    ),
    onFilter: (value, record) =>
      record[dataIndex].toString().toLowerCase().includes(value.toLowerCase()),
    onFilterDropdownOpenChange: (visible) => {
      if (visible) {
        setTimeout(() => searchInput.current?.select(), 100);
      }
    },
    render: (text) =>
      searchedColumn === dataIndex ? (
        <Highlighter
          highlightStyle={{
            backgroundColor: '#ffc069',
            padding: 0,
          }}
          searchWords={[searchText]}
          autoEscape
          textToHighlight={text ? text.toString() : ''}
        />
      ) : (
        text
      ),
  });
  const columns = [
    {
      title: 'Id',
      dataIndex: 'id',
      render: (index) => <p>{index + 1}</p>,
      width: '5%'
    },
    {
      title: 'Mã Loại SP',
      dataIndex: 'code',
      width: '10%'
    },
    {
      title: 'Tên Loại SP',
      dataIndex: 'name',
      width: '10%',
      ...getColumnSearchProps('name'),
    },
    {
      title: 'Kí hiệu gợi ý',
      dataIndex: 'keyword',
      width: '40%'
    },
    {
      title: 'Trạng thái',
      dataIndex: 'status',
      width: '10%'
    },
    {
      title: 'Thao tác',
      dataIndex: 'action',
      width: '25%'
    },
  ];
  const data = [
    {
      key: '1',
      id: '1',
      code: 'TV001',
      name: 'Tivi',
      keyword: 'tivi, manhinh, television',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '2',
      id: '2',
      code: 'TN001',
      name: 'Tai nghe',
      keyword: 'tainghe, headphone, bluetooth, head',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '3',
      id: '3',
      code: 'BL001',
      name: 'Bộ Loa',
      keyword: 'boloa, loa, Loa, speaker, megaphone',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '4',
      id: '4',
      code: 'BP001',
      name: 'Bàn phím',
      keyword: 'banphim, phim, keyword, keyboard, board',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '5',
      id: '5',
      code: 'CM001',
      name: 'Chuột máy tính',
      keyword: 'chuotmaytinh, cmt, mouse, click',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '5',
      id: '5',
      code: 'CMT001',
      name: 'Cây máy tính',
      keyword: 'caymaytinh, cay, maytinh, pc, computer',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '6',
      id: '6',
      code: 'LP001',
      name: 'Laptop',
      keyword: 'laptop, maytinh',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    
  ];
  
  // rowSelection object indicates the need for row selection
  const rowSelection = {
    onChange: (selectedRowKeys, selectedRows) => {
      console.log(`selectedRowKeys: ${selectedRowKeys}`, 'selectedRows: ', selectedRows);
    },
  };
  
  return (
    <>
      <div style={{ display: 'flex', overflowY: 'scroll'}}>
        <SideMenu />
        <div style={{ overflowY: 'scroll', backgroundColor: '#e6e6e6'}}>
          <Header />
          <Typography.Title level={3} style={{ padding: '10px' }}><WalletOutlined /> Danh Sách Loại Sản Phẩm</Typography.Title>
          <Table
            rowSelection={{
              type: selectionType,
              ...rowSelection,
            }}
            columns={columns}
            dataSource={data} 
          />
        </div>
      </div>
    </>
  )
}

export default Category