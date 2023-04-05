import { CheckOutlined, DeleteOutlined, EditOutlined, SearchOutlined, VerticalAlignBottomOutlined, WalletOutlined } from '@ant-design/icons'
import Header from 'admin/components/Header'
import SideMenu from 'admin/components/SideMenu'
import { Typography, Table, Button, Image, Input, Space } from 'antd'
import React, { useState, useRef } from 'react'
import Highlighter from 'react-highlight-words'
import { Link } from 'react-router-dom'


const Product = () => {
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
      fixed: 'left',
      width: 50,
      render: (index) => <p>{index + 1}</p>,
    },
    {
      title: 'Hình',
      fixed: 'left',
      width: 100,
      dataIndex: 'image',
    },
    {
      title: 'Tên sản phẩm',
      dataIndex: 'name',
      ...getColumnSearchProps('name'),
      width: 300
    },
    {
      title: 'Số lượng',
      dataIndex: 'qty',
      width: 70
    },
    {
      title: 'Đã bán',
      dataIndex: 'qtySell',
      width: 60
    },
    {
      title: 'Tồn kho',
      dataIndex: 'qtyPack',
      width: 60
    },
    {
      title: 'Loại sản phẩm',
      dataIndex: 'category',
      ...getColumnSearchProps('category'),
      width: 150
    },
    {
      title: 'Trạng Thái',
      dataIndex: 'status',
      width: 100
    },
    {
      title: 'Nhập hàng',
      dataIndex: 'input',
      width: 100,
      fixed: 'right'
    },
    {
      title: 'Thao tác',
      dataIndex: 'action',
      width: 180,
      fixed: 'right'
    },
  ];
  const data = [
    {
      key: '1',
      id: '1',
      image: <Image src='https://www.lg.com/vn/images/tivi/md07551245/gallery/D-01.jpg' style={{ width: 60}} />,
      name: 'LG UHD 4K 43inch | 55UQ7550',
      qty: 32,
      qtySell: 12,
      qtyPack: 21,
      category: 'Tivi Màn Hình Phẳng',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      input: <Button type='primary' value="small"><VerticalAlignBottomOutlined /> Nhập</Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '2',
      id: '2',
      image: <Image src='https://www.lg.com/vn/images/tivi/md07528212/gallery/D-01.jpg' style={{ width: 60}} />,
      name: 'LG UHD 4K 55inch | 55UP7550',
      qty: 32,
      qtySell: 12,
      qtyPack: 21,
      category: 'Tivi Google LCD',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      input: <Button type='primary' value="small"><VerticalAlignBottomOutlined /> Nhập</Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '3',
      id: '3',
      image: <Image src='https://www.lg.com/vn/images/tivi/md07529413/gallery/1100_1.jpg' style={{ width: 60}} />,
      name: 'LG FHD LED 43inch | 43LM5750',
      qty: 32,
      qtySell: 12,
      qtyPack: 21,
      category: 'Tivi LED',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      input: <Button type='primary' value="small"><VerticalAlignBottomOutlined /> Nhập</Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '4',
      id: '4',
      image: <Image src='https://www.drcare.vn/wp-content/uploads/2021/12/DrCare-dan-am-thanh-sk600-cover-600x600.jpg' style={{ width: 60}} />,
      name: 'Dàn âm thanh Dr.Care DR-SK 600',
      qty: 32,
      qtySell: 12,
      qtyPack: 21,
      category: 'Dàn Âm Thanh',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      input: <Button type='primary' value="small"><VerticalAlignBottomOutlined /> Nhập</Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '5',
      id: '5',
      image: <Image src='https://hoanglongcomputer.vn/media/product/2306-pi72012a.png' style={{ width: 60}} />,
      name: 'CORE I7 12700 | RAM 16G | NVME 256G | RTX 2060 12G',
      qty: 32,
      qtySell: 12,
      qtyPack: 21,
      category: 'Cây máy tính',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      input: <Button type='primary' value="small"><VerticalAlignBottomOutlined /> Nhập</Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '6',
      id: '6',
      image: <Image src='https://www.lg.com/vn/images/tivi/md07551245/gallery/D-01.jpg' style={{ width: 60}} />,
      name: 'LG UHD 4K 43inch | 55UQ7550',
      qty: 32,
      qtySell: 12,
      qtyPack: 21,
      category: 'Tivi Màn Hình Phẳng',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      input: <Button type='primary' value="small"><VerticalAlignBottomOutlined /> Nhập</Button>,
      action: <div style={{ display: 'flex'}}>
        <Button type='primary' value="small" style={{ backgroundColor: 'yellow', color: 'black'}}><Link to={`/admin/product/update/1`}><EditOutlined /> Sửa</Link></Button>
        <Button type='primary' value="small" style={{ backgroundColor: 'red'}}><DeleteOutlined /> Xóa</Button>
      </div>,
    },
    {
      key: '7',
      id: '7',
      image: <Image src='https://www.lg.com/vn/images/tivi/md07551245/gallery/D-01.jpg' style={{ width: 60}} />,
      name: 'LG UHD 4K 43inch | 55UQ7550',
      qty: 32,
      qtySell: 12,
      qtyPack: 21,
      category: 'Tivi Màn Hình Phẳng',
      status: <Button type='primary' value="small" style={{ backgroundColor: "green"}}><CheckOutlined /></Button>,
      input: <Button type='primary' value="small"><VerticalAlignBottomOutlined /> Nhập</Button>,
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
          <Typography.Title level={3} style={{ padding: '10px' }}><WalletOutlined /> Danh Sách Sản Phẩm</Typography.Title>
          <Table
            rowSelection={{
              type: selectionType,
              ...rowSelection,
            }}
            columns={columns}
            dataSource={data}
            scroll={{
              x: 1300,
            }}
          />
        </div>
      </div>
    </>
  )
}

export default Product