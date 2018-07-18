class SideBar extends React.Component {
    constructor(props) {
        super(props);
        this.state = {};
    }
    render() {

        const sidePaneContent = [
            {
                icon: 'iconfont icon-ceju',
                title: '测距',
                color:'#0d5bac',
            },
            {
                icon: 'iconfont icon-zhoubian',
                title: '周边',
                color: '#0d5bac',
            }
            ,
            {
                icon: 'iconfont icon-qingkong',
                title: '清空',
                color: '#0d5bac',
            }
            ,
            {
                icon: 'iconfont icon-tuli',
                title: '图例',
                color: '#0d5bac',
            }
        ];
        return (
            <div className="SideBar">
                <ul>
                    {
                        sidePaneContent.map(item => {

                            return (<li ><i className={item.icon} style={{ color: item.color }} title={item.title}></i></li>)
                        })
                    }
                </ul>
            </div>
        );
    }
}

