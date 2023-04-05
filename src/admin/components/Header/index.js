import { BellFilled, HomeOutlined } from '@ant-design/icons/lib/icons'
import { Badge, Button, Card, Image, Popover, Space } from 'antd'
import Typography from 'antd/es/typography/Typography'
import React, { useState } from 'react'
import { Link } from 'react-router-dom'

const Header = () => {
    const [open, setOpen] = useState(false);
    const [openAvatar, setOpenAvatar] = useState(false);
    const hide = () => {
        setOpen(false);
    };
    const handleOpenChange = (newOpen) => {
        setOpen(newOpen);
    };

    const handleOpenAvatar = (newAvatar) => {
        setOpenAvatar(newAvatar);
    };

    return (
        <div className='app-header' style={{ backgroundColor: "#85a3e0", width: '82.52vw', height: '10vh'}}>
            <Image 
                src="../../image/logo.png"  
                width={50}
            />
            <Space>
                <Badge count={10} dot>
                    <Popover
                        content={<Typography>Bạn có 20 thông báo chưa đọc</Typography>}
                        trigger="hover"
                        open={open}
                        onOpenChange={handleOpenChange}
                        >
                        <Button style={{ backgroundColor: 'transparent', border: 'none'}}>
                            <BellFilled style={{ fontSize: '20px'}} />
                        </Button>
                    </Popover>
                </Badge>
                <div>|</div>
                <Link to="/" style={{ color: 'black', fontSize: '18px'}}><HomeOutlined /> Website</Link>
                <div>|</div>
                <Popover
                    content={
                    <Card
                        title={<div>
                                <Image src="https://avatarfiles.alphacoders.com/826/thumb-82642.png" style={{ borderRadius: '50%', width: '100px', margin: '15px 50px 0', alignItems: 'center'}} />
                                <Typography.Title level={5} style={{ textAlign: 'center', margin: '0', fontWeight: 700}}>ADMIN</Typography.Title>
                                <Typography style={{ textAlign: 'center', paddingBottom: '15px'}}>0894112325</Typography>
                            </div>}
                        style={{
                          width: 250,
                          backgroundColor: '#4dffd2'
                        }}
                      >
                        <div style={{ display: 'flex', justifyContent: 'space-around'}}>
                            <Button>Chi Tiết</Button>
                            <Button>Thoát</Button>
                        </div>
                    </Card>
                    }
                    trigger="hover"
                    open={openAvatar}
                    onOpenChange={handleOpenAvatar}
                    >
                    <div style={{ display: 'flex'}}>
                        <Image src='https://avatarfiles.alphacoders.com/826/thumb-82642.png' style={{ borderRadius: '50%', width: '30px', marginRight: '5px' }} />
                        <Typography style={{ fontSize: '18px', cursor: 'pointer', fontWeight: '600' }}>ADMIN</Typography>
                    </div>
                </Popover>
            </Space>
        </div>
    )
}

export default Header