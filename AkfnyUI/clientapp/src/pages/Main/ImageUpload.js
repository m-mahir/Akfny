// imports the React Javascript Library
import React from "react";
//Card
import Card from "@material-ui/core/Card";
import CardActionArea from "@material-ui/core/CardActionArea";

import Fab from "@material-ui/core/Fab";
import Grid from "@material-ui/core/Grid";
import Avatar from "@material-ui/core/Avatar";

import red from "@material-ui/core/colors/red";

import SearchIcon from "@material-ui/icons/Search";
import AccountCircle from "@material-ui/icons/AccountCircle";

// Search
import Paper from "@material-ui/core/Paper";
import InputBase from "@material-ui/core/InputBase";
import Divider from "@material-ui/core/Divider";
import IconButton from "@material-ui/core/IconButton";
import CloseIcon from "@material-ui/icons/Close";
import ReplayIcon from "@material-ui/icons/Replay";

//Tabs
import { withStyles } from "@material-ui/core/styles";

const imageGallery = [
  "https://raw.githubusercontent.com/dxyang/StyleTransfer/master/style_imgs/mosaic.jpg",
  "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg/1280px-Van_Gogh_-_Starry_Night_-_Google_Art_Project.jpg",
  "https://raw.githubusercontent.com/ShafeenTejani/fast-style-transfer/master/examples/dora-maar-picasso.jpg",
  "https://pbs.twimg.com/profile_images/925531519858257920/IyYLHp-u_400x400.jpg",
  "https://raw.githubusercontent.com/ShafeenTejani/fast-style-transfer/master/examples/dog.jpg",
  "http://r.ddmcdn.com/s_f/o_1/cx_462/cy_245/cw_1349/ch_1349/w_720/APL/uploads/2015/06/caturday-shutterstock_149320799.jpg",
];

const styles = (theme) => ({
  root: {
    backgroundColor: "transparent",
    width: "100%",
    display: "flex",
    justifyContent: "center",
    alignItems: "flex-end",
    "& .MuiPaper-root.MuiCard-root.MuiPaper-elevation1.MuiPaper-rounded": {
      borderRadius: "50%",
      margin: "10px",
      width: "150px",
      height: "150px",
    },
    "& .MuiButton-startIcon.MuiButton-iconSizeSmall": {
      marginLeft: '20px',
      marginRight: '20px'
    }
  },
  icon: {
    margin: theme.spacing(1),
  },
  iconHover: {
    margin: theme.spacing(1),
    "&:hover": {
      color: red[800],
    },
  },
  cardHeader: {
    textalign: "center",
    align: "center",
    backgroundColor: "white",
  },
  input: {
    display: "none",
  },
  title: {
    color: "#98276e",
    fontWeight: "bold",
    fontFamily: "Tajawal",
    align: "center",
  },
  label: {
    margin: 0,
  },
  button: {
    color: "#98276e",
    width: "150px",
    height: "150px",
  },
  secondaryButton: {
    color: "gray",
  },
  typography: {
    margin: theme.spacing(1),
    backgroundColor: "default",
  },
});

class ImageUploadCard extends React.Component {
  state = {
    mainState: "initial", // initial, search, gallery, uploaded
    imageUploaded: 0,
    selectedFile: null,
  };

  componentDidUpdate(prevProps) {
    if (this.props.imageUrl !== prevProps.imageUrl)
      this.setState({
        mainState: this.props.imageUrl ? "uploaded" : "initial", // initial, search, gallery, uploaded
        imageUploaded: this.props.imageUrl ? 1 : 0,
        selectedFile: this.props.imageUrl || null,
      });
  }

  handleUploadClick = (event) => {
    var file = event.target.files[0];
    const reader = new FileReader();
    var url = reader.readAsDataURL(file);

    reader.onloadend = function (e) {
      this.setState({
        selectedFile: [reader.result],
      });
      this.props.setImageUrl(reader.result);
    }.bind(this);

    this.setState({
      mainState: "uploaded",
      selectedFile: event.target.files[0],
      imageUploaded: 1,
    });
  };

  handleSearchClick = (event) => {
    this.setState({
      mainState: "search",
    });
  };

  handleGalleryClick = (event) => {
    this.setState({
      mainState: "gallery",
    });
  };

  renderInitialState() {
    const { classes, theme } = this.props;
    const { value } = this.state;

    return (
      <React.Fragment>
        <input
          accept="image/*"
          className={classes.input}
          id="contained-button-file"
          multiple
          type="file"
          onChange={this.handleUploadClick}
        />
        <label htmlFor="contained-button-file" className={classes.label}>
          <Fab component="span" className={classes.button}>
            <AccountCircle style={{ height: "170px", width: "170px" }} />
          </Fab>
        </label>
      </React.Fragment>
    );
  }

  handleSearchURL = (event) => {
    var file = event.target.files[0];
    var reader = new FileReader();
    var url = reader.readAsDataURL(file);

    reader.onloadend = function (e) {
      this.setState({
        selectedFile: [reader.result],
      });
      this.props.setImageUrl(reader.result);
    }.bind(this);

    this.setState({
      selectedFile: event.target.files[0],
      imageUploaded: 1,
    });
  };

  handleImageSearch(url) {
    var filename = url.substring(url.lastIndexOf("/") + 1);
    this.setState({
      mainState: "uploaded",
      imageUploaded: true,
      selectedFile: url,
      fileReader: undefined,
      filename: filename,
    });
    this.props.setImageUrl(url);
  }

  handleSeachClose = (event) => {
    this.setState({
      mainState: "initial",
    });
  };

  renderSearchState() {
    const { classes } = this.props;

    return (
      <Paper className={classes.searchRoot} elevation={1}>
        <InputBase className={classes.searchInput} placeholder="Image URL" />
        <IconButton
          className={classes.button}
          aria-label="Search"
          onClick={this.handleImageSearch}
        >
          <SearchIcon />
        </IconButton>
        <Divider className={classes.searchDivider} />
        <IconButton
          color="primary"
          className={classes.secondaryButton}
          aria-label="Close"
          onClick={this.handleSeachClose}
        >
          <CloseIcon />
        </IconButton>
      </Paper>
    );
  }

  handleAvatarClick(value) {
    var filename = value.url.substring(value.url.lastIndexOf("/") + 1);
    this.setState({
      mainState: "uploaded",
      imageUploaded: true,
      selectedFile: value.url,
      fileReader: undefined,
      filename: filename,
    });
    this.props.setImageUrl(value.url);
  }

  renderGalleryState() {
    const { classes } = this.props;
    const listItems = this.props.imageGallery.map((url) => (
      <div
        onClick={(value) => this.handleAvatarClick({ url })}
        style={{
          padding: "5px 5px 5px 5px",
          cursor: "pointer",
        }}
      >
        <Avatar src={url} />
      </div>
    ));

    return (
      <React.Fragment>
        <Grid>
          {listItems}
          <IconButton
            color="primary"
            className={classes.secondaryButton}
            aria-label="Close"
            onClick={this.handleSeachClose}
          >
            <ReplayIcon />
          </IconButton>
        </Grid>
      </React.Fragment>
    );
  }

  renderUploadedState() {
    const { classes, theme } = this.props;

    return (
      <React.Fragment>
        <CardActionArea>
          <img
            width="100%"
            height="150px"
            className={classes.media}
            src={this.state.selectedFile}
          />
          <button
            type="button"
            onClick={this.imageResetHandler}
            style={{
              color: "#fff",
              backgroundColor: "black",
              position: "absolute",
              opacity: 0.6,
              width: "30px",
              height: "30px",
              top: 20,
              right: 20,
              fontsize: "15px",
              borderRadius: "50%",
              border: "2px solid black",
            }}
            data-dismiss="modal"
            aria-label="Close"
          >
            <span aria-hidden="true">&times;</span>
          </button>
        </CardActionArea>
      </React.Fragment>
    );
  }

  imageResetHandler = (event) => {
    this.setState({
      mainState: "initial",
      selectedFile: null,
      imageUploaded: 0,
    });
    this.props.setImageUrl();
  };

  render() {
    const { classes, theme } = this.props;
    return (
      <React.Fragment>
        <div className={classes.root}>
          <Card className={this.props.cardName}>
            {(this.state.mainState == "initial" && this.renderInitialState()) ||
              (this.state.mainState == "search" && this.renderSearchState()) ||
              (this.state.mainState == "gallery" &&
                this.renderGalleryState()) ||
              (this.state.mainState == "uploaded" &&
                this.renderUploadedState())}
          </Card>
        </div>
      </React.Fragment>
    );
  }
}

export default withStyles(styles, { withTheme: true })(ImageUploadCard);
