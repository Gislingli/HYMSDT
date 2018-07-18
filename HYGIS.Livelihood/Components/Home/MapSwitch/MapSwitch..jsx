class MapSwitch extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            bool:false
        };
    }
    handleOut = () => {
        this.setState({
            bool: false
        });
    }
    handleEnter = () => {
        this.setState({
            bool: true
        });
    }
    switchMap = () => {
        this.setState({
            bool: true
        });
    }
    render() {
        let ps = this.props;
        let s = this.state;

        let VectorStyle = {};
        if (!s.bool) VectorStyle = { 'left': '76px' };
        if (s.bool) VectorStyle = { 'left': '168px' };

        let ImageStyle = {};
        if (ps.vectorOrImage) {
            ImageStyle = { 'background': 'url("../../../Refers/Image/Vector-selected.png") no-repeat' };
            VectorStyle.background = 'url("../../../Refers/Image/Image.png") no-repeat';
        }
        if (!ps.vectorOrImage) {
            ImageStyle = { 'background': 'url("../../../Refers/Image/Image-selected.png") no-repeat' };
            VectorStyle.background = 'url("../../../Refers/Image/Vector.png") no-repeat';
        } 
        return (
            <div onMouseEnter={this.handleEnter} onMouseLeave={this.handleOut}>
                <div className="MapSwitchImage" style={ImageStyle}>
            </div>
                <div className="MapSwitchVector" style={VectorStyle} onClick={ps.switchMap}>
            </div>
            </div>
        );
    }
}

