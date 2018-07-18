
class CommentBox extends React.Component {
   constructor(props) {
        super(props);
        this.state = {
            SearchBar_status: true,
            vectorOrImage:true
        };
    }
    //隐藏或显示搜索框
   ToggleSearchBar_status=()=> {
       if (this.state.SearchBar_status) this.setState({ SearchBar_status: false });
       if (!this.state.SearchBar_status) this.setState({ SearchBar_status: true });
   }

   switchMap = () => {
       if (this.state.vectorOrImage) this.setState({ vectorOrImage: false });
       if (!this.state.vectorOrImage) this.setState({ vectorOrImage: true });
   }
   render() {
      return (
          <div className="commentBox">
              <TitleBar ToggleSearchBar_status={this.ToggleSearchBar_status} />      
              {this.state.SearchBar_status ? <SearchBar ToggleSearchBar_status={this.ToggleSearchBar_status} /> : null}
              <MapSwitch switchMap={this.switchMap} vectorOrImage={this.state.vectorOrImage} />
              <LogoBar />
              <Map vectorOrImage={this.state.vectorOrImage}/>
              <SideBar />
  
        </div>
    );
  }
}


$(function () {
    __leafletExtends__();
    index = ReactDOM.render(<CommentBox />, document.getElementById('content'));
});