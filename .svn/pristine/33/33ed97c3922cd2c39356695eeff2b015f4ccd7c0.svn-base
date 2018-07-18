const { Input, Icon } = antd;

class SearchBar extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            location:''
        };
    }
    emitEmpty = () => {
        this.locationInput.focus();
        this.setState({ location: '' });
    }
    onChangeLocation = (e) => {
        this.setState({ location: e.target.value });
    }
    render() {
        let ps = this.props;
        {/* 输入查询内容 */ }
        const { location } = this.state;
        {/* 清除搜索栏内容 */ }
        const suffix = location ? <Icon type="close-circle" style={{ color: 'rgba(0,0,0,.25)' }} onClick={this.emitEmpty} /> : null;
        {/* 导航栏内容 */ }
        const paneContent = [
            {
                color: '#2cbb2e',
                content: [
                    '景区景点', '海盐绿道', '美丽乡村'
                ],
                title: '休闲旅游',
                icon: 'iconfont icon-XXLY'
            },
            {
                color: '#4a91e3',
                content: [
                    '特色餐饮', '电影院', '酒店住宿', '超市', '银行', 'ATM','公共厕所'
                ],
                title: '生活服务',
                icon: 'iconfont icon-SHFW'
            }
            ,
            {
                color: '#60c6b0',
                content: [
                    '公交站点', '公共自行车', '停车场', '长途客运站', '加油站'
                ],
                title: '交通出行',
                icon: 'iconfont icon-JTCX'
            }
            ,
            {
                color: '#f4a725',
                content: [
                    '文化场馆', '学区划分', '学校', '活动中心'
                ],
                title: '文化教育',
                icon: 'iconfont icon-WHJY'
            }
            ,
            {
                color: '#de4e64',
                content: [
                    '综合医院', '专科医院', '药店', '诊所','疾病预防机构',''
                ],
                title: '医疗卫生',
                icon: 'iconfont icon-YLWS'
            }
        ];
        return (
            <div className="searchBar">
                {/* 搜索栏 */}
                <div className="search">
                    <Input
                        placeholder="请输入关键字搜地点、查公交"
                        prefix={<Icon type="search" style={{ color: 'rgba(0,0,0,.25)', marginTop: '4px' }} />}
                        suffix={suffix}
                        value={location}
                        onChange={this.onChangeLocation}
                        ref={node => this.locationInput = node}
                        style={{margin: '8px', width: '408px'}}
                    />
                </div>
                {/* 导航栏 */}
                {
                    paneContent.map(item => {
                    return (<div className="paneBox">
                        <div style={{ width: '100%', height: '35%', display: 'block' }}>
                                <div className={item.icon} style={{ color: item.color, display: 'inline-block' }}></div>
                                <div style={{ display: 'inline-block', marginLeft:'17px' }}> {item.title}</div>
                        </div>
                        <div style={{ width: '100%', height: '60%', color: item.color, display: 'block', lineHeight:'28px' }}>
                                {
                                item.content.map(contentItem => {
                                    return <div title={contentItem} style={{ marginLeft: '35px', display: 'inline-block', cursor: 'pointer' }}>{contentItem}</div>;
                                    }
                                    )
                                }
                        </div>
                    </div>)
                    }
                    )
                }
                {/* 底部回缩按钮 */}
                <div style={{ width: '100%', height: '20px', textAlign: 'center' }} >
                    <Icon type="caret-up" style={{ color: 'rgba(0,0,0,.25)', cursor: 'pointer', fontSize: '20px' }} title="缩小" onClick={ps.ToggleSearchBar_status} />
                </div>
            </div>
        );
    }
}

