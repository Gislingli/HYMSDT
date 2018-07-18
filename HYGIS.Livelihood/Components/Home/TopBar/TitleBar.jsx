class TitleBar extends React.Component {
    constructor(props) {
        super(props);
        this.state = {};
    }
    render() {
       let ps = this.props;
       //let s = this.state;
        //debugger
        return (
            <div className="TitleBar">
                <div className="title"></div>
                <i title="点击查看" onClick={ps.ToggleSearchBar_status} className="iconfont icon-caidan" ></i>
            </div>
        );
    }
}

